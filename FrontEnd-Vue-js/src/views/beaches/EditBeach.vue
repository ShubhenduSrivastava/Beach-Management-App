<script setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

let beachToUpdate = reactive({
    id: 0,
    beachName: "",
    place: "",
    imageUrl: ""
});

const route = useRoute();
const router = useRouter();

onMounted(() => {
    axios.get(`http://localhost:5083/Beach${route.params.id}`)
        .then((response) => {
            beachToUpdate.beachName = response.data.beachName;
            beachToUpdate.place = response.data.place;
            beachToUpdate.imageUrl = response.data.imageUrl;
            beachToUpdate.id = response.data.id;
        })
})

const updateBeach = () => {
    axios.put("http://localhost:5083/Beach",beachToUpdate)
    .then(()  => {
        router.push("/");
    })
}
</script>

<template>
    <div class="container mt-5">
        <form @submit.prevent="updateBeach">
            <legend>Add a New item</legend>
            <div class="mb-3">
                <label for="txtBeachName" class="form-label">Beach Name</label>
                <input type="text" class="form-control" id="txtBeachName" aria-describedby="emailHelp"
                    v-model="beachToUpdate.beachName">

            </div>
            <div class="mb-3">
                <label for="txtLocation" class="form-label">Location</label>
                <input type="text" class="form-control" id="txtLocation" aria-describedby="emailHelp"
                    v-model="beachToUpdate.place">

            </div>
            <div class="mb-3">
                <label for="txtImageUrl" class="form-label">Image URL</label>
                <input type="text" class="form-control" id="txtImageUrl" aria-describedby="emailHelp"
                    v-model="beachToUpdate.imageUrl">

            </div>
            <button type="submit" class="btn btn-primary">Update</button>
        </form>
    </div>
</template>
