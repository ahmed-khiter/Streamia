class Tools {
    urlMonitor() {
        let pattern = new RegExp('^(https?:\\/\\/)?' + // protocol
            '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|' + // domain name
            '((\\d{1,3}\\.){3}\\d{1,3}))' + // OR ip (v4) address
            '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + // port and path
            '(\\?[;&a-z\\d%_.~+=-]*)?' + // query string
            '(\\#[-a-z\\d_]*)?$', 'i'); // fragment locator

        document.querySelectorAll('.tools-url-monitor').forEach(tum => tum.addEventListener('keyup', function () {
            if (!!pattern.test(this.value)) {
                document.querySelectorAll('.tools-url-action').forEach(tua => tua.style.display = 'block');
            } else {
                document.querySelectorAll('.tools-url-action').forEach(tua => tua.style.display = 'none');
            }
        }));
    }
}