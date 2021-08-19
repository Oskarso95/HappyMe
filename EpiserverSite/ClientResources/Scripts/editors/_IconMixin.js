define([
  "dojo/_base/declare",
  "dojo/store/Memory",
  "xstyle/css!../css/happyme.css",
], function (declare, memorystore) {
  return declare("geta-epi-cms/editors/_IconMixin", null, {
    _createMemoryStore: function () {
      var iconStyleSheet = this._getIconStyleSheet();
      var memoryData = [];

      if (iconStyleSheet != null) {
        for (var i = 0; i < iconStyleSheet.cssRules.length; i++) {
          var cssRule = iconStyleSheet.cssRules[i];

          if (
            !cssRule.selectorText ||
            cssRule.selectorText.indexOf("::before") == -1
          ) {
            continue;
          }

          var selectorTexts = cssRule.selectorText.split(":");

          if (selectorTexts.length > 3) {
            continue;
          }
          var selectorText = selectorTexts[0].substring(1);
          var iconName = selectorText.substring(5);
          var label = '<i class="' + selectorText + '"></i> ' + iconName;
          memoryData.push({ id: selectorText, name: iconName, label: label });
        }
        memoryData.sort(this._sort);
      }

      return new memorystore({ data: memoryData });
    },

    _getIconStyleSheet: function () {
      for (var i = 0; i < document.styleSheets.length; i++) {
        try {
          var sheetInfo = document.styleSheets[i];
          if (sheetInfo.href.indexOf("happyme") > -1) {
            return sheetInfo;
          }
        } catch (e) {}
      }
      return null;
    },

    _sort: function (a, b) {
      if (a.name < b.name) {
        return -1;
      }
      if (a.name > b.name) {
        return 1;
      }
      return 0;
    },
    _trimString: function (str) {
      return str.replace(/^\s+|\s+$/g, "");
    },
  });
});
