
$(function () {

    $('input:enabled:visible:first').focus();
});

//#region   Bind json data to screen input
$.fn.bindJSON = function (json) {

    // iterate each matching form
    return this.each(function () {
        // iterate the elements within the form
        if (json != null) {
            $(':input', this).each(function () {
                var type = this.type, tag = this.tagName.toLowerCase();
                if (type == 'text' || type == 'password' || tag == 'textarea' || tag == 'select')
                    if (json[this.name] != undefined && json[this.name] != null) {
                        this.value = json[this.name];
                        if (this.className == "numeric-box")
                            $(this).setComma();
                    }
            });
        }
    });
};
//#endregion

$.fn.clearForm = function () {
    return this.each(function () {
        var type = this.type, tag = this.tagName.toLowerCase();
        if (tag == 'form' || tag == 'div')
            return $(':input', this).clearForm();
        if (type == 'text' || type == 'password' || tag == 'textarea')
            this.value = '';
        else if (type == 'checkbox' || type == 'radio')
            this.checked = false;
        else if (tag == 'select') {
            // Akat K. 2011-07-19 : first option is index 0
            this.selectedIndex = 0;
            //this.selectedIndex = -1;
        }

        $(this).removeClass("highlight");
    });
};



//#region    Check current browser is IE 8
navigator.sayswho = (function () {
    var ua = navigator.userAgent, tem,
        M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
    if (/trident/i.test(M[1])) {
        tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
        return 'IE ' + (tem[1] || '');
    }
    if (M[1] === 'Chrome') {
        tem = ua.match(/\b(OPR|Edge)\/(\d+)/);
        if (tem != null) return tem.slice(1).join(' ').replace('OPR', 'Opera');
    }
    M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
    if ((tem = ua.match(/version\/(\d+)/i)) != null) M.splice(1, 1, tem[1]);
    return M.join(' ');
})();
var isIe8 = function () {
    return navigator.sayswho == 'MSIE 8';
}
//#endregion


//#region    Hide/Show loading screen
var loading = function (visible) {
    if (visible) {
        $('.loading-box').css('display', 'block');
    } else {
        $('.loading-box').css('display', 'none');
    }
}

$.fn.BoxLoading = function (IsShow) {

    var oldPositionStyle = $(this).css('position');

    if ($(this).length) {
        if (IsShow == true) {

            console.log($(this).css('position'));

            $(this).attr('data-position-loading', $(this).css('position'));

            if ($(this).css('position') != 'relative') {
                $(this).css('position', 'relative');
            }

            $(this).append('<section class="ScreenLoading"><img src="../Content/images/loading_animation.gif" /></section>');

        } else {
            if ($(this).attr('data-position-loading') != undefined) {
                $(this).css('position', $(this).attr('data-position-loading'));
            }

            $(this).find('section.ScreenLoading').remove();
        }
    }

}

//#endregion

//#region   Convert data

// Convert C# DateTime to Json date
var ConvertToJsonDate = function (val) {
    if (typeof (val) !== "undefined" && val !== null)
        return new Date(parseInt(val.substring(6)));
    else
        return null;
}

//#endregion

var ToNumber = function (txt) {
    var x = '';
    if (txt === undefined || txt == null) return null;
    for (var i = 0; i < txt.length; i++) {
        x += txt[i];
    }
    if (typeof x !== "number" && typeof x !== "string" || x === "") {
        return NaN;
    } else {
        x = Number(x);
        return x === Math.floor(x) ? x : NaN;
    }
}

function integer(x) {
    if (typeof x === "string" && /^\s*(\+|-)?\d+\s*$/.test(x)) {
        x = Number(x);
    }
    if (typeof x === "number") {
        return x === Math.floor(x) ? x : NaN;
    }
    return NaN;
}

/**
 * ShowStringMoneyFormat(str, n, x)
 
 * @param integer str: string value
 * @param integer n: length of decimal
 * @param integer x: length of sections

1234..format();           // "1,234"
12345..format(2);         // "12,345.00"
123456.7.format(3, 2);    // "12,34,56.700"
123456.789.format(2, 4);  // "12,3456.79"
**/
var ShowStringMoneyFormat = function (str, n, x) {
    if (str == '') {
        return '';
    } else {
        var num = ToNumber(str);
        var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\.' : '$') + ')';
        return num.toFixed(Math.max(0, ~~n)).replace(new RegExp(re, 'g'), '$&,');
    }
}