

var convertCTOJSDate = function (str) {
    if (!str) return str;

    return new Date(parseInt(str.replace('Date(', '').replace(')', '').replace('/', '').replace('/', '').replace('-', '')));
}