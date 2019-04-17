<template>
<div>
<default-layout></default-layout>
<h2>This is the page to buy/sell stocks.</h2>
<form action="">
  <span>Symbol: {{symbol}}</span>
  <span>Current Price: {{price}}</span>
  <!-- <input type="number" min="0.01" step="0.01" placeholder="23.50"/> -->
  <span>Number of Shares:</span>
  <input type="number" placeholder="500" max="" min="0" id="numberOfShares">
  <button class="btn btn-primary" @click.prevent="MakeTrade">Purchase Stock</button>
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
        this.trade.price = parseFloat(resp);
        this.$forceUpdate();
    });
    },
    

methods: {
    MakeTrade(){
      this.trade.symbol = globals.symbol;
      this.trade.numOfShares = parseInt(document.getElementById('numberOfShares').value);  
      fetch(`${process.env.VUE_APP_REMOTE_API}/api/BuySell/`, {
          method:'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
          },
          body: JSON.stringify(this.trade),
        })
          .then((response) => {
            if (response.ok) {
              this.$router.push({ path: '/portfolio' });
            }
          })
          .catch((err) => console.error(err));
      
      
  }},
computed: {
    symbol(){
        return globals.symbol;
    }
    // trade(){
    //     trade.symbol = globals.symbol;
    //     return trade.symbol;
    // }
},
    data() {
        return{
            user: null,
            price: String,

        trade: {
            symbol: '',
            price: 0.00,
            numOfShares: 0
        }
    }
}
}
</script>

<style>
h2 {
    margin-left: 2%;
}

</style>
