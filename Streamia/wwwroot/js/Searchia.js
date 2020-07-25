class Searchia {
    constructor(typingDelay) {
        this.renderStyle();
        let searchia = document.getElementById('searchia');
        let input = searchia.querySelector('input');
        let searchiaDropdown = document.createElement('div');
        let searchiaInitialResult = document.createElement('div');

        searchiaDropdown.classList.add('searchia-dropdown', 'searchia-hidden');
        searchiaInitialResult.classList.add('searchia-result');
        searchiaInitialResult.innerHTML = 'Searching...';
        searchiaDropdown.appendChild(searchiaInitialResult);
        searchia.appendChild(searchiaDropdown);

        this.searchia = searchia;
        this.searchiaDropdown = searchiaDropdown;
        this.input = input;
        this.typingDelay = typingDelay || 500;
        this.results = [];
    }

    renderStyle() {
        document.body.innerHTML += `
            #searchia {
                position: relative;
            }

            #searchia .searchia-dropdown {
                position: absolute;
                z-index: 9999;
                left: 0;
                right: 0;
                background-color: #FFF;
                border: 1px solid #f1f1f1;
                max-height: 250px;
                overflow-y: auto;
            }

            #searchia .searchia-hidden {
                display: none;
            }

            #searchia .searchia-result {
                font-size: 16px;
                padding: 10px 5px;
                border-bottom: 1px solid #f1f1f1;
                cursor: pointer;
                transition: all .4s ease;
            }

            #searchia .searchia-result:last-child {
                border-bottom: none;
            }

            #searchia .searchia-result:hover {
                background-color: #f1f1f1;
            }
        `;
    }

    onTyping(callback) {
        let self = this;
        this.input.addEventListener('keyup', function () {
            let currentValue = this.value;
            self.searchiaDropdown.classList.remove('searchia-hidden');
            if (!self.timeout) {
                self.timeout = setTimeout(() => {
                    callback(currentValue);
                    self.results = [];
                    self.timeout = null;
                }, self.typingDelay);
            }
        });
    }

    onResult(id, text) {
        let searchResult = document.createElement('div');
        searchResult.classList.add('searchia-result');
        searchResult.setAttribute('data-id', id);
        searchResult.innerHTML = text;
        this.searchiaDropdown.appendChild(searchResult);
        this.results.push(searchResult);
    }

    onResultClick(callback) {
        this.results.forEach(result => {
            result.addEventListener('click', function () {
                callback(this.getAttribute('data-id'));
            });
        });
    }
}