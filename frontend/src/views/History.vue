<template>
  <default-layout>
      <h2>Your Transaction History</h2>  
        <div id="portfolio-table">
          <table class="table table-striped" id="history-table">
          <thead class="thead-dark">
          <tr>
            <th scope="col">Date</th>
            <th scope="col">Symbol</th>
            <th scope="col">Number of Shares</th>
            <th scope="col">Price</th>
          </tr>
        </thead>
        <tbody>
          <tr  v-for="transaction in transactions" :key="transaction.Id">
            <td>{{new Date(transaction.date).date}}</td>
            <td>{{transaction.symbol}}</td>
            <td>{{transaction.numOfShares}}</td>
            <td>{{transaction.price}}</td>
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
  name: 'history',
  components: {
    DefaultLayout
  },
  data() {
    return{
      user: null,
      transactions: []
    }
  },
  beforeMount(){
    this.user = auth.getUser();

  },
  created() {
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
  background-color: white;
}

.table > tbody > tr > td {
  vertical-align: middle;
}

#history-table {
    border: 2px solid black;
    border-radius: 5px !important;
}

h2 {
  margin-left: 0%;
  margin-bottom: 1%;
}
</style>
