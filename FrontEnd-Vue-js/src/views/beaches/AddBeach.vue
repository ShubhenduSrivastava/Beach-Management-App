<script setup>
import { reactive } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';


let newBeach = reactive({
    beachName:"",
    place: "",
    imageUrl:""
});

const router = useRouter();

const addBeach = () => {
    axios.post("http://localhost:5083/Beach", newBeach).then(() => {
        router.push("/");
    });
};

</script>

<template>
    <div class="container mt-5">
        <form @submit.prevent="addBeach">
            <legend>Add a New item</legend>
            <div class="mb-3">
                <label for="txtBeachName" class="form-label">Beach Name</label>
                <input type="text" class="form-control" id="txtBeachName" aria-describedby="emailHelp" v-model="newBeach.beachName">
               
            </div>
            <div class="mb-3">
                <label for="txtLocation" class="form-label">Location</label>
                <input type="text" class="form-control" id="txtLocation" aria-describedby="emailHelp" v-model="newBeach.place">
               
            </div>
            <div class="mb-3">
                <label for="txtImageUrl" class="form-label">Image URL</label>
                <input type="text" class="form-control" id="txtImageUrl" aria-describedby="emailHelp" v-model="newBeach.imageUrl">
                
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    </div>
</template>
