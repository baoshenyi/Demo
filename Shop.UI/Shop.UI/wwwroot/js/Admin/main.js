var app = new Vue({
    el: '#app',
    data: {
        price: 0,
        showPrice: true,
        loading: false
    },
    methods: {
        togglePrice: function () {
            this.showPrice = !this.showPrice;
        },
        alert: function (v) {
            alert(v)
        },
        getProducts: function () {
            this.loading = true;
            axios.get('/Admin/products')
                .then(function (response) {
                    console.log(response);
                })
                .catch(function (error){
                    console.log(error);
                })
                .then(function () {
                    this.loading = false;
                });
        }
    },
    computed: {
        formatPrice: function() {
            return "$" + this.price;
        }
    }
});