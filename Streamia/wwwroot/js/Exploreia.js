class Exploreia {
    constructor() {
        this.pathStack = [];
        this.explorer = null;
        this.loader = null;
        this.serverDropdown = null;
        this.folders = null;
    }

    render(serverList) {
        this.renderStyle();
        let exServers = this.renderServerList(serverList);
        let exTemplate = document.createElement('div');
        let exLoader = document.createElement('div');
        let exContent = document.createElement('div');
        let exServerList = document.createElement('div');
        let exServerDropdown = document.createElement('select');
        let exCurrentPath = document.createElement('div');
        let exFolders = document.createElement('div');
        let exButtons = document.createElement('div');

        exTemplate.classList.add('ex-hidden');
        exLoader.classList.add('ex-loader');
        exContent.classList.add('ex-content');
        exServerList.classList.add('ex-server-list');
        exServerDropdown.classList.add('ex-server-dropdown');
        exCurrentPath.classList.add('ex-current-path');
        exFolders.classList.add('ex-folders');
        exButtons.classList.add('ex-buttons');
        exServerDropdown.innerHTML = exServers;
        exServerList.appendChild(exServerDropdown);
        exContent.appendChild(exServerList);
        exContent.appendChild(exCurrentPath);
        exContent.appendChild(exFolders);
        exContent.appendChild(exButtons);
        exTemplate.appendChild(exLoader);
        exTemplate.appendChild(exContent);
        exTemplate.id = 'exploreia';

        document.body.appendChild(exTemplate);
        this.explorer = exTemplate;
        this.loader = exLoader;
        this.serverDropdown = exServerDropdown;
        this.folders = exFolders;

        this.prepareEvents();
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
        let serverListTemplate = '<option value="0">-- Select Server --</option>';
        serverList.forEach(server => {
            serverListTemplate += `
                <option value="${server.id}">${server.name}</option>
            `;
        });
        return serverListTemplate;
    }

    renderDirectories(directories) {
        this.resetFolders();
        directories = directories.split(/\r?\n/g);
        directories.forEach(dir => {
            if (dir == '') {
                return;
            }
            let exEntry = document.createElement('div');
            let exIcon = document.createElement('i');
            let exFile = document.createElement('span');

            icon.classList.add('fa');
            if (this.isDirectory(dir)) {
                exIcon.classList.add('fa-folder', 'text-warning');
            } else {
                exIcon.classList.add('fa-file-video-o', 'text-secondary');
            }

            exFile.innerHTML = this.prepareFiles(dir);
            exEntry.classList.add('ex-entry');
            exEntry.appendChild(exIcon);
            exEntry.appendChild(exFile);

            this.folders.appendChild(exEntry);
        });
    }

    createPath() {
        if (this.pathStack.length === 0) {
            return '/';
        }
        return '/' + this.pathStack.join('/');
    }

    prepareFiles(path) {
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

    open() {
        this.explorer.classList.remove('ex-hidden');
    }

    close() {
        this.explorer.classList.add('ex-hidden');
    }

    reset() {
        this.pathStack = [];
    }

    resetFolders() {
        this.folders.innerHTML = '';
    }
}