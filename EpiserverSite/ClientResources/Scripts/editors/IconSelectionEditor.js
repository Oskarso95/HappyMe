define([
    "dojo/_base/declare",
    "geta-epi-cms/editors/_IconMixin",
    "epi/shell/form/AutoCompleteSelectionEditor"
],
function (
    declare,
    _IconMixin,
    AutoCompleteSelectionEditor
) {
    return declare("geta-epi-cms/editors/_IconMixin", [_IconMixin, AutoCompleteSelectionEditor], {
        labelAttr: "label",
        labelType: "html",

        postMixInProperties: function() {
            this.inherited(arguments);
            this.store = this._createMemoryStore();
        }
    });
});