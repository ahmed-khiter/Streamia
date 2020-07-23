class Exploreia {
    constructor() {
        this.pathStack = [];
        this.explorer = null;
    }

    render(serverList) {
        this.renderStyle();
        let serverListTemplate = this.renderServerList(serverList);
        let exploreiaTemplate = document.createElement('div');
        exploreiaTemplate.id = 'exploreia';
        exploreiaTemplate.classList.add('ex-hidden');
        exploreiaTemplate.innerHTML += `
            <div class="ex-content">
                <div class="ex-loader"></div>
                <div class="ex-server-list">
                    <select class="ex-server-dropdown">
                        <option value="0">-- Select Server --</option>
                        ${serverListTemplate}
                    </select>
                </div>
                <div class="ex-current-path"></div>
                <div class="ex-folders"></div>
                <div class="ex-buttons"></div>
            </div>
        `;
        document.body.appendChild(exploreiaTemplate);
        this.explorer = document.getElementById('exploreia');
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
        let serverListTemplate = '';
        serverList.forEach(server => {
            serverListTemplate += `
                <option value="${server.id}">${server.name}</option>
            `;
        });
        return serverListTemplate;
    }

    renderDirectories(directories) {
        directories = directories.split(/\r?\n/g);
        directories.forEach(dir => {
            if (dir == '') {
                return;
            }
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
            this.explorer.querySelector('.ex-loader').classList.remove('ex-hidden');
        } else {
            this.explorer.querySelector('.ex-loader').classList.add('ex-hidden');
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
}