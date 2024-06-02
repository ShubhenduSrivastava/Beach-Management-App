<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import ConfirmDeletePopUp from '@/components/ConfirmDeletePopUp.vue';

const beachCollection = ref([]);

const deleteItemId = ref(0);

let deleteModalInstance;

onMounted(() => {
    deleteModalInstance = new window.bootstrap.Modal(document.getElementById('deletePopup'));
    axios.get("http://localhost:5083/Beach")
        .then((response) => {
            beachCollection.value = response.data;
        })
})

const openDeleteModal = (id) => {
    deleteItemId.value = id;
    deleteModalInstance.show();
}

const confirmDelete = () => {
    axios.delete(`http://localhost:5083/Beach/${deleteItemId.value}`)
        .then(() => {
            beachCollection.value = beachCollection.value.filter(_ => _.id !== deleteItemId.value);
            deleteModalInstance.hide();
        })

}

</script>

<template>
    <div class="container ">

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <div class="col" v-for="item in beachCollection" :key="item.id">
                <div class="card">
                    <img :src="item.imageUrl" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">{{ item.beachName }}</h5>
                        <p class="card-text">Location - {{ item.place }}</p>
                        <RouterLink class="btn btn-primary" :to="`/edit/${item.id}`"> Edit</RouterLink>
                        <button type="button" @click="($event) => openDeleteModal(item.id)" class="btn btn-danger">Delete</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="but mt-5">
            <RouterLink class="btn btn-primary" to="/add"> Add</RouterLink>

        </div>
        <ConfirmDeletePopUp @confirm-delete-click="confirmDelete"></ConfirmDeletePopUp>
    </div>
</template>
