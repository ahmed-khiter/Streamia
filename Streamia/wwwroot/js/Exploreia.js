class Exploreia {
    constructor(options) {
        this.pathStack = [];
        this.fileStack = [];
        this.options = options;
    }

    render(serverList) {
        this.renderStyle();
        let exServers = this.renderServerList(serverList);
        let exTemplate = document.createElement('div');
        let exLoader = document.createElement('div');
        let exLoaderIcon = document.createElement('i');
        let exContent = document.createElement('div');
        let exServerList = document.createElement('div');
        let exServerDropdown = document.createElement('select');
        let exCurrentPath = document.createElement('div');
        let exFolders = document.createElement('div');
        let exButtons = document.createElement('div');
        let exBackButton = document.createElement('button');
        let exPickButton = null;

        exTemplate.classList.add('ex-hidden');
        exLoader.classList.add('ex-loader', 'ex-hidden');
        exLoaderIcon.classList.add('fa', 'fa-fw', 'fa-pulse', 'fa-spinner', 'fa-3x');
        exContent.classList.add('ex-content');
        exServerList.classList.add('ex-server-list');
        exServerDropdown.classList.add('ex-server-dropdown', 'form-control');
        exCurrentPath.classList.add('ex-current-path');
        exFolders.classList.add('ex-folders');
        exButtons.classList.add('ex-buttons');
        exBackButton.classList.add('btn', 'btn-secondary', 'ex-hidden');
        exBackButton.innerHTML = '<i class="fa fa-arrow-left"></i> Back';

        if (this.options.pickDirectory === true) {
            exPickButton = document.createElement('button');
            exPickButton.classList.add('main-btn', 'ex-hidden');
            exPickButton.innerHTML = '<i class="fa fa-check"></i> Select this folder';
            exButtons.appendChild(exPickButton);
            this.pickButton = exPickButton;
        }

        exLoader.appendChild(exLoaderIcon);

        exServers.forEach(server => {
            exServerDropdown.appendChild(server);
        });

        exServerList.appendChild(exServerDropdown);
        exButtons.appendChild(exBackButton);
        exContent.appendChild(exLoader);
        exContent.appendChild(exServerList);
        exContent.appendChild(exCurrentPath);
        exContent.appendChild(exFolders);
        exContent.appendChild(exButtons);
        exTemplate.appendChild(exContent);
        exTemplate.id = 'exploreia';

        document.body.appendChild(exTemplate);
        this.explorer = exTemplate;
        this.loader = exLoader;
        this.serverDropdown = exServerDropdown;
        this.currentPath = exCurrentPath;
        this.folders = exFolders;
        this.backButton = exBackButton;
    }

    renderStyle() {
        document.body.innerHTML += `
            <style>
                #exploreia {
                    position: fixed;
                    top: 0;
                    left: 0;
                    right: 0;
                    bottom: 0;
                    z-index: 9999999;
                    background-color: rgba(0,0,0,.6);
                }

                .ex-hidden {
                    display: none;
                }

                #exploreia .ex-loader {
                    position: absolute;
                    top: 0;
                    left: 0;
                    right: 0;
                    bottom: 0;
                    z-index: 99999;
                    text-align: center;
                    background-color: rgba(255,255,255,.6);
                    padding-top: 30%;
                }

                #exploreia .ex-content {
                    position: relative;
                    width: 450px;
                    padding: 10px;
                    margin: 25vh auto;
                    background-color: #FFF;
                }

                #exploreia .ex-server-list,
                #exploreia .ex-current-path,
                #exploreia .ex-folders
                {
                    border-bottom: 1px solid #f1f1f1;
                    padding-bottom: 10px;
                    padding-top: 10px;
                }

                #exploreia .ex-folders {
                    height: 200px;
                    overflow-y: auto;
                }

                #exploreia .ex-entry {
                    padding: 15px 5px;
                    border-bottom: 1px solid #f1f1f1;
                    cursor: pointer;
                    transition: all .4s linear;
                }

                #exploreia .ex-entry:last-child {
                    border-bottom: none;
                }

                #exploreia .ex-entry:hover {
                    background-color: #f1f1f1;
                }

                #exploreia .ex-buttons {
                    padding-top: 10px;
                }
            </style>
        `;
    }

    renderServerList(serverList) {
        let serverListOptions = [];
        let option = document.createElement('option');
        option.value = 0;
        option.innerHTML = '-- Select Server --';
        serverListOptions.push(option);
        serverList.forEach(server => {
            let serverOption = document.createElement('option');
            serverOption.value = server.id;
            serverOption.innerHTML = server.name;
            serverListOptions.push(serverOption);
        });
        return serverListOptions;
    }

    renderDirectories(directories) {
        this.resetFolders();
        this.resetFiles();
        directories = directories.split(/\r?\n/g);
        directories.forEach(dir => {
            if (dir != '') {
                let fileFolder = this.prepareFile(dir);
                let exEntry = document.createElement('div');
                let exIcon = document.createElement('i');
                let exFile = document.createElement('span');

                exIcon.classList.add('fa');
                if (this.isDirectory(dir)) {
                    this.fileStack.push(fileFolder);
                    exIcon.classList.add('fa-folder', 'text-warning');
                } else {
                    exIcon.classList.add('fa-file-video-o', 'text-secondary');
                }

                exFile.innerHTML = fileFolder;
                exEntry.classList.add('ex-entry');
                exEntry.setAttribute('data-path', dir);
                exEntry.appendChild(exIcon);
                exEntry.append(' ');
                exEntry.appendChild(exFile);

                this.folders.appendChild(exEntry);
            }
        });
        this.toggleLoader(false);
        this.updateCurrentPath();
        this.toggleButtons();
    }

    createPath() {
        if (this.pathStack.length === 0) {
            return '/';
        }
        return '/' + this.pathStack.join('/');
    }

    prepareFile(path) {
        if (path.slice(-1) == '/') {
            return path.slice(0, path.length - 1);
        }
        return path;
    }

    isDirectory(path) {
        return path.slice(-1) == '/';
    }

    toggleLoader(shouldShow) {
        if (shouldShow) {
            this.loader.classList.remove('ex-hidden');
        } else {
            this.loader.classList.add('ex-hidden');
        }
    }

    toggleButtons() {
        if (this.pathStack.length > 0) {
            this.backButton.classList.remove('ex-hidden');
            this.pickButton.classList.remove('ex-hidden');
        } else {
            this.backButton.classList.add('ex-hidden');
            this.pickButton.classList.add('ex-hidden');
        }
    }

    updateCurrentPath() {
        this.currentPath.innerHTML = this.createPath();
    }

    open() {
        this.explorer.classList.remove('ex-hidden');
    }

    close() {
        this.explorer.classList.add('ex-hidden');
    }

    reset() {
        this.pathStack = [];
        this.fileStack = [];
    }

    resetFolders() {
        this.folders.innerHTML = '';
    }

    resetFiles() {
        this.fileStack = [];
    }

    onChange(callback) {
        this.onServerChange(callback);
        this.onDirectoryChange(callback);
        this.onBackButtonClick(callback);
    }

    onServerChange(callback) {
        let self = this;
        this.serverDropdown.addEventListener('change', function () {
            let selectedValue = parseInt(this.value);
            self.toggleLoader(true);
            self.currentServer = selectedValue;
            callback(selectedValue, self.createPath());
        });
    }

    onDirectoryChange(callback) {
        let self = this;
        document.addEventListener('click', function (e) {
            if (e.target && e.target.getAttribute('class') === 'ex-entry') {
                let currentPath = e.target.getAttribute('data-path');
                if (self.isDirectory(currentPath)) {
                    self.toggleLoader(true);
                    self.pathStack.push(self.prepareFile(currentPath));
                    callback(self.currentServer, self.createPath());
                }
            }
        });
    }

    onBackButtonClick(callback) {
        let self = this;
        this.backButton.addEventListener('click', function () {
            self.toggleLoader(true);
            self.pathStack.pop();
            callback(self.currentServer, self.createPath());
        });
    }

    onPickButtonClick(callback) {
        if (this.options.pickDirectory === true) {
            let self = this;
            this.pickButton.addEventListener('click', function () {
                callback(self.fileStack);
            });
        }
    }

    onAbort(callback) {
        let self = this;
        window.onbeforeunload = function () {
            if (self.currentServer > 0) {
                callback(self.currentServer);
            }
        }
    }
}