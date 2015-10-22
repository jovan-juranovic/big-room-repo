window.util.serverProxy = (function (utility) {

    return {

        getUsers: function (callback) {
            $.getJSON("/api/v1/mvc/users", callback);
        },
        getUser: function (id, callback) {
            $.getJSON("/api/v1/mvc/users/" + id, callback);
        },
        editUser: function(user, callback) {
            utility.putJson("/api/v1/mvc/users", user, callback);
        }
    };
})(util.utility);