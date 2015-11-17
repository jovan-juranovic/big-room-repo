window.util.serverProxy = (function (utility) {

    var usersUrl = "/api/v1/mvc/users/";
    var categoriesUrl = "/api/v1/mvc/categories/";
    var productsUrl = "/api/v1/mvc/products/";
    var reviewsUrl = "/api/v1/mvc/reviews/";
    var ordersUrl = "/api/v1/mvc/orders/";

    return {

        getUsers: function (callback) {
            $.getJSON(usersUrl, callback);
        },
        getUser: function (id, callback) {
            $.getJSON(usersUrl + id, callback);
        },
        editUser: function(user, callback) {
            utility.putJson(usersUrl, user, callback);
        },
        deleteUser: function(id, callback) {
            utility.deleteJson(usersUrl + id, "", callback);
        },
        getCategories: function(callback) {
            $.getJSON(categoriesUrl, callback);
        },
        getCategory: function(id, callback) {
            $.getJSON(categoriesUrl + id, callback);
        },
        addCategory: function(category, callback) {
            utility.postJson(categoriesUrl, category, callback);
        },
        editCategory: function(category, callback) {
            utility.putJson(categoriesUrl, category, callback);
        },
        deleteCategory: function(id, callback) {
            utility.deleteJson(categoriesUrl + id, "", callback);
        },
        getProducts: function(callback) {
            $.getJSON(productsUrl, callback);
        },
        getProduct: function(id, callback) {
            $.getJSON(productsUrl + id, callback);
        },
        editProduct: function (product, callback) {
            utility.putJson(productsUrl, category, callback);
        },
        getReviews: function(callback) {
            $.getJSON(reviewsUrl, callback);
        },
        getOrders: function(callback) {
            $.getJSON(ordersUrl, callback);
        }
};
})(util.utility);