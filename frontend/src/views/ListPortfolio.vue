<template>
  <default-layout>
      <h2 class="portfolio-h2">Your Portfolio</h2>  
        <div id="portfolio-table">
          <table class="table table-striped">
          <thead class="thead-dark">
          <tr>
            <th scope="col">Symbol</th>
            <th scope="col">Number of Shares</th>
            <th scope="col">Current Price</th>
            <th scope="col">Total Market Value</th>
            <th scope="col"> +/-</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="stock in portfolio" :key="stock.Id">
            <td>{{ stock.symbol }}</td>
            <td>{{ stock.numberOfShares }}</td>
            <td>${{parseFloat(stock.price).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }}</td>
            <td>${{parseFloat(CalculateMarketValue(stock.price, stock.numberOfShares)).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</td>
            <td></td>
            <td>
                <button class="btn btn-success" :value="stock.symbol" @click="BuyShares($event)">Buy</button>
                <button class="btn btn-danger" :value="stock.symbol" @click="SellShares($event)">Sell</button>              
            <!-- <td class="align-middle"></td> -->
            </td>
          </tr>
        </tbody>
      </table>
        </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';
import {globals} from '@/main.js';
import { constants } from 'crypto';

export default {
  name: 'ListPortfolio',
  components: {
    DefaultLayout
  },
methods: {
  
BuyShares(event){
  console.log("We did it.");
  globals.symbol = event.target.value;
  
  console.log(event.target.numOfShares);
  globals.isBuy = true;
  this.$router.push({name:'trades'});
},
SellShares(event){
  console.log("We did it.");
  globals.numberOfShares = event.path[2].childNodes[1].innerText;
  globals.symbol = event.target.value;
  globals.isBuy = false;
  this.$router.push({name:'trades'});
},

GetCurrentPrice(stock){
  fetch(`https://cloud.iexapis.com/beta/stock/${stock.symbol}/price?token=pk_cdd72b15fa2a4735897c36067dd39008`)
  .then((response) => {
    return response.text();
  })
  .then((resp) => {
    stock.price = resp;
    this.$forceUpdate();
  });
},
CalculateMarketValue(price, shares) {
  let marketValue = price * shares;
  return marketValue;
},
CalculateTotalInvestment(transactions) {
  for(let symbol in transactions){
    
  }


}
},
  data() {
    return{
      user: null,
      portfolio: [],
      transactions: {}
    }
  },
  beforeMount(){
    this.user = auth.getUser();

  },
    created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/api/BuySell/`, {
      method: 'GET',
      headers: {
        Authorization: 'Bearer ' + auth.getToken(),
      },
      credentials: 'same-origin',
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.portfolio = data;
        //need to loop through portfolio for each symbol
        data.forEach(stock => {
          this.GetCurrentPrice(stock);
          console.log(process.env.VUE_APP_REMOTE_API);
        })
        // GetCurrentPrice(data.symbol);
      })
      .catch((err) => console.error(err));

          fetch(`${process.env.VUE_APP_REMOTE_API}/api/BuySell/AllTransactions`, {
      method: 'GET',
      headers: {
        Authorization: 'Bearer ' + auth.getToken(),
      },
      credentials: 'same-origin',
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.transactions = data;
        CalculateTotalInvestment(transactions);       
      })
      .catch((err) => console.error(err));
  }
}
</script>

<style scoped>
button {
  margin-top: 0px !important;
  padding-left: 10px;
  padding-right: 10px !important;
}

th {
  color: #bffbfb !important;
}

table {
  text-align: center;
}

.table > tbody > tr > td {
  vertical-align: middle;
}

#portfolio-table {
    border: 2px solid black;
    border-radius: 5px !important;
}

.portfolio-h2 {
  margin-left: 0%;
  margin-bottom: 1%;
}
</style>