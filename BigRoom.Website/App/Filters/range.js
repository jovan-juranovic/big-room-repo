(function() {
    angular
        .module("BigRoomApp")
        .filter("range", range);

    function range() {
        return function (val, rng, base) {
            if (base) {
                rng = base - parseInt(rng, 10);
            } else {
                rng = parseInt(rng, 10);
            }
            for (var i = 0; i < rng; i++)
                val.push(i);
            return val;
        };
    }
})();