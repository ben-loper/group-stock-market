<template>
  <default-layout>
    <div id="portfolio">
      <h1>Portfolio Page</h1> 
      <p>Hello! {{user.fName}}</p>  

            <table class="table table-striped">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Symbol</th>
            <th scope="col">Number of Shares</th>
            <th scope="col">Current Price</th>
            <th scope="col">Total Market Value</th>
            <th scope="col"> +/-</th>
            <th scope="col">BUY/SELL</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="stock in portfolio" :key="stock.Id">
            <td>{{ stock.symbol }}</td>
            <td>{{ stock.numberOfShares }}</td>
            <td></td>
            <td></td>
            <td></td>
            <td><router-link
                :to="{ name: 'trades'}"
                tag="button"
                class="btn btn-outline-primary btn-sm align-middle"
                >Buy or Sell</router-link></td>
            <!-- <td class="align-middle"></td> -->
          </tr>
        </tbody>
      </table>

    </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
  name: 'ListPortfolio',
  components: {
    DefaultLayout
  },
methods: {
      GetCurrentPrice(userPortfolio){
      userPortfolio.forEach(stock => {
        fetch(`$https://cloud.iexapis.com/beta/stock/${stock.symbol}/price?token=pk_876eb03a33ae4de0b3b9dbf6eaa9c2bd`)
        .then((response) => {
          console.log(response.body);
          return response.text()
          
        })
        .then((data) => {
          console.log(data);
        })
      });
}
},

  data() {
    return{
      user: null,
      portfolio: []
    }
  },
  beforeMount(){
    this.user = auth.getUser();

  },
    created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/api/portfolio/`, {
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
        GetCurrentPrice(this.portfolio);
      })
      .catch((err) => console.error(err));
      
      
  }}
</script>

<style scoped>
button {
  margin-right: 5px !important;
}
span.badge {
  margin-right: 5px;
}
.actions .btn {
  margin-top: 0px;
}
</style>