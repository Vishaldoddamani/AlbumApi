<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        

        <ul >
            <li v-for="x in todos" v-bind:key="x">
                {{ x.text }}
            </li>

        </ul>
        <h1>
            {{ info }}
        </h1>

        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</p>
    </div>
    
</template>

<script>
import axios from "axios";
    export default {
        name: 'Home',
        data () {
           return {
                   todos: [
                    { text: 'Learn JavaScript' },
                    { text: 'Learn Vue.js' },
                    { text: 'Build Something Awesome' }
                    ],

                    info : null
            }
        },
        mounted(){
            
                axios.get("https://localhost:44369/api/Album/GetAlbumDetails?UserId=1")
                .then(response => (this.info = response));
        },
       
        props: {
            msg: String
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

