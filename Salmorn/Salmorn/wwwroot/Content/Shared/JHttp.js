var JHttp = $.extend({

    // Ajax callback : Http method Post
    Post: function (url, data, successFunc, errorFunc, BoxLoadingId = false) {
        this._AJax("POST", url, data,
            function (result) {

                if (successFunc != null && typeof (successFunc) == 'function') {
                    successFunc(result);
                }

            }, errorFunc, true, BoxLoadingId);
    },

    // Ajax callback : Http method Get
    Get: function (url, data, successFunc, errorFunc) {

        this._AJax("GET", url, data, successFunc, errorFunc, true);

    },

    // Ajax callback : Http method Put
    Put: function (url, data, successFunc, errorFunc) {

        this._AJax("PUT", url, data, successFunc, errorFunc, true);

    },

    // Ajax callback : Http method Delete
    Delete: function (url, data, successFunc, errorFunc) {

        this._AJax("DELETE", url, data, successFunc, errorFunc, true);

    },
    ConvertDateBeforePostBack: function (obj) {

        if (obj.length === undefined) {

            for (var j in obj) {
                if (obj[j] instanceof Date && obj[j] != 'Invalid Date') {
                    obj[j] = obj[j].toISOString();
                }
            }

        } else {

            var L = obj.length;
            for (var i = 0; i < L; i++) {
                var ob = obj[i];
                for (var j in ob) {
                    if (ob[j] instanceof Date) {
                        ob[j] = ob[j].toISOString();
                    }
                }
            }

        }

        return obj;
    },
    _AJax: function (httpMethod, url, data, successFunc, errorFunc, isLoading, BoxLoadingId) {

        console.log('data', data);

        var objJson = null;
        var boxLoading = typeof BoxLoadingId !== 'undefined' ? $('#' + BoxLoadingId) : null;
        //if (data != null)
        //    objJson = $.toJSON(data);
        if (data != null)
            objJson = JSON.stringify(data);  // Convert to json

        loading(isLoading);

        if (boxLoading != null) {
            boxLoading.BoxLoading(true);
        }

        $.ajax({
            type: httpMethod,
            url: url,
            data: objJson,
            dataType: 'json',
            //beforeSend: function (xhr) {
            //    /* Authorization header */
            //    xhr.setRequestHeader("Authorization", "Bearer ");
            //},
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result.type == 1) {
                    alertError('Error!', result.message);
                }

                if (successFunc != null && typeof (successFunc) == 'function') {
                    successFunc(result);
                }

                loading(false);
                if (boxLoading != null) {
                    boxLoading.BoxLoading(false);
                }
            },
            error: function (result) {
                alertError('Error!', result.message);
                if (errorFunc != null && typeof (errorFunc) != 'undefined') {
                    errorFunc(result);
                }
                loading(false);
                if (boxLoading != null) {
                    boxLoading.BoxLoading(false);
                }
            },
            async: true,
            //contentType: contentType,
            //processData: processData,
        });
    },

    ConvertIncorrectText: function (txt) {
        var ntxt = txt;
        if (ntxt != undefined) {
            //Convert &amp; to &
            ntxt = ntxt.replace(/&amp;/g, "&");

            /* --- Merge --- */
            ntxt = ntxt.replace(/&lt;/g, "<");
            ntxt = ntxt.replace(/&gt;/g, ">");
            /* ------------- */
        }

        return ntxt;
    },

    isFunction: function (functionToCheck) {
        var getType = {};
        return functionToCheck && getType.toString.call(functionToCheck) === '[object Function]';
    }

});