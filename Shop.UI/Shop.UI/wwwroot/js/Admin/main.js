var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        products: []
    },
    methods: {
        getProducts: function () {
            this.loading = true;
            axios.get('/Admin/products')
                .then(response => {
                    console.log(response);
                    this.products = response.data;
                })
                .catch(error =>{
                    console.log(error);
                })
                .then(() => {
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