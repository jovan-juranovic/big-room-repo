window.util.utility = (function () {
    var rebuildObservableArray, activateModalFromTemplate, postJson, putJson;

    rebuildObservableArray = function (observableArray, serverArray, ItemFactory) {
        var newArray = [];
        $.each(serverArray, function (index) {
            newArray.push(new ItemFactory(this, index));
        });

        observableArray(newArray);
    };

    activateModalFromTemplate = function (module, templateName) {
        var $el, $modal;
        $el = $("<div>");
        $('body').append($el);
        ko.renderTemplate(templateName, module, null, $el.get(0));
        $modal = $el.children(":first");

        $modal.on('hidden.bs.modal', function () {
            // call close function if it is defined
            if (module.close) {
                module.close();
            }

            $el.remove();
        });

        $modal.on('shown.bs.modal', function () {
            // on snow focus first input if it exists
            $('input:text:visible:first', this).focus();
        });

        module.closeModal = function () {
            $modal.modal('hide');
        };

        // allow model closing by default (if canClose was not specified)
        if (module.canClose || module.canClose === undefined) {
            $modal.modal();
        } else {
            $modal.modal({
                keyboard: false,
                backdrop: 'static'
            });
        }
    };

    postJson = function (url, data, callback) {

        if ($.isFunction(data)) {
            callback = data;
            data = undefined;
        }

        $.ajax({
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            type: "POST",
            url: url,
            data: JSON.stringify(data),
            success: callback
        });
    };

    putJson = function (url, data, callback) {

        if ($.isFunction(data)) {
            callback = data;
            data = undefined;
        }

        $.ajax({
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            type: "PUT",
            url: url,
            data: JSON.stringify(data),
            success: callback
        });
    };

    return {
        rebuildObservableArray: rebuildObservableArray,
        activateModalFromTemplate: activateModalFromTemplate,
        postJson: postJson,
        putJson: putJson
    };
})();