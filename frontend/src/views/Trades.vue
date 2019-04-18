<template>
<div>
<default-layout></default-layout>
<h2 v-if="isBuy" class="trades-h2">Buy</h2>
<h2 v-if="!isBuy" class="trades-h2">Sell</h2>
<form v-if="isBuy" action="">
  <img class="company-logo-trade" v-bind:src="image.url">
  <div><strong>Symbol: </strong>{{symbol}}</div>
  <div><strong>Current Price: </strong>${{parseFloat(price).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</div>
  <!-- <input type="number" min="0.01" step="0.01" placeholder="23.50"/> -->
  <div><strong>Number of Shares:</strong>
  <input type="number" placeholder="0" max="" min="0" id="numberOfShares"></div>
  <button class="btn btn-primary" id="buy-button" @click.prevent="BuyStocks">Purchase Stock</button>
</form>
<form v-if="!isBuy" action="">
  <img class="company-logo-trade" v-bind:src="image.url">
  <div><strong>Symbol: </strong>{{symbol}}</div>
  <div><strong>Current Price: </strong>${{parseFloat(price).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</div>
  <!-- <input type="number" min="0.01" step="0.01" placeholder="23.50"/> -->
  <div><strong>Current Number of Shares: </strong>{{parseFloat(numberOfShares).toFixed().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</div>
  <div><strong>Number of Shares: </strong>
  <input type="number" placeholder="0" :max="numberOfShares" min="0" id="numberOfShares"></div>
  <button class="btn btn-primary" id="sell-button" @click.prevent="SellStocks">Sell Stock</button>
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
    fetch(`https://cloud.iexapis.com/beta/stock/${globals.symbol}/logo?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        .then((response) => {
            return response.json();
        })
        .then((resp) => {
            this.image= resp;
            // this.$forceUpdate();
        })
        .catch((err) => console.error(err));
    
    },
    

methods: {
    BuyStocks(){
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
      
      
  },
  SellStocks(){
    if(parseInt(document.getElementById('numberOfShares').value) <= globals.numberOfShares && parseInt(document.getElementById('numberOfShares').value) > 0){
      this.trade.symbol = globals.symbol;
      this.trade.numOfShares = parseInt(document.getElementById('numberOfShares').value) * -1;  
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
    }
     else{
       alert("You can only sell up to the amount of shares you own!");
     }
     
  }
 },
computed: {
    symbol(){
        return globals.symbol;
    },
    numberOfShares(){
        return globals.numberOfShares;
    },
    // trade(){
    //     trade.symbol = globals.symbol;
    //     return trade.symbol;
    // }
    isBuy(){
      return globals.isBuy;
    }
},
    data() {
        return{
            user: null,
            price: String,
            image: {},

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
.trades-h2 {
    text-align: center;
}

#buy-button {
    background-color: #611aa6 !important;
    border: 1px solid #611aa6 !important;
    color: white;
    margin-left: 1% !important;
    width: 11%;
}

#buy-button:hover {
    background-color: blueviolet !important;
}

#sell-button {
    background-color: #611aa6 !important;
    border: 1px solid #611aa6 !important;
    color: white;
    margin-left: 1% !important;
    width: 9%;
}

#sell-button:hover {
    background-color: blueviolet !important;
}

#numberOfShares {
  width: 7%;
  text-align: center;
}

.company-logo-trade {
  border: 2px solid black;
  border-radius: 5px;
  margin-bottom: 1%;
}

</style>
