<template>
<div>
<default-layout></default-layout>
<h2>This is the page to buy/sell stocks.</h2>
<form action="">
  <span>Symbol: {{symbol}}</span>
  <span>Current Price: {{price}}</span>
  <!-- <input type="number" min="0.01" step="0.01" placeholder="23.50"/> -->
  <span>Number of Shares:</span>
  <input type="number" placeholder="500" max="" min="0">
  <button class="btn btn-primary">Purchase Stock</button>
</form>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';
import {globals} from '@/main.js';

export default {
    name: 'Trades',
    components: {
        DefaultLayout,
},
created(){
    fetch(`https://cloud.iexapis.com/beta/stock/${globals.symbol}/price?token=pk_cdd72b15fa2a4735897c36067dd39008`)
    .then((response) => {
        return response.text();
    })
    .then((resp) => {
        this.price = resp;
        this.$forceUpdate();
    });
    },

computed: {
    symbol(){
        return globals.symbol;
    }
},
    data() {
        return{
            user: null,
            price: String
        }
    }
}
</script>

<style>
h2 {
    margin-left: 2%;
}

</style>
