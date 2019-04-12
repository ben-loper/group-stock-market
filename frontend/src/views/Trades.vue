<template>
<div>
<default-layout></default-layout>
<h1>This is the page to buy/sell stocks.</h1>
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

</style>
