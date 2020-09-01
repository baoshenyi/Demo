var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            name: "",
            description: "",
            price: ""
        },
        products: []
    },
    methods: {
        getProducts() {
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
        },
        createProduct() {
            this.loading = true;
            axios.post('/Admin/product', this.productModel)
                .then(response => {
                    console.log(response);
                })
                .catch(error => {
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