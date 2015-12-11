﻿function CacheManager() {
    var self = this;

    self.Get = function (key) {
        var itemJSON = localStorage.getItem(key);

        if (!itemJSON)
            return undefined;

        return JSON.parse(itemJSON);
    }

    self.Set = function (key, obj) {
        localStorage.setItem(key, JSON.stringify(obj));
    }

    self.Clear = function (key) {
        localStorage.removeItem(key);
    }

    self.Exists = function(key) {
        return localStorage.getItem(key) == undefined;
    }
}

var cache = new CacheManager();