<template>
<div>
<default-layout></default-layout>
<h2>This is the page to buy/sell stocks.</h2>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
    name: 'Trades',
    components: {
        DefaultLayout,
}
}
</script>

<style>
h2 {
    margin-left: 2%;
}

</style>
