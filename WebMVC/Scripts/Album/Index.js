'use strict';
document.addEventListener("DOMContentLoaded", function (event) {
    loadData();
});

function loadData() {
    ajaxGet("/Album/GetAll").done(function (data) {
        var tbody = document.getElementById("tbodyAlbum");
        data.forEach(function (item, index) {
            tbody.innerHTML = "<tr>" +
                "<td>" + item.Id + "</td>" +
                "<td>" + item.Name + "</td>" +
                "<td><img style='width:50px; height:50px;' src='" + item.Image + "'/></td>" +
                "<td><button onclick='deleteAlbum(" + item.Id + ")' class='btn btn-danger'><i class='fas fa-trash'></i></button></td>" +
                "<td><button onclick='getById(" + item.Id + ")' class='btn btn-warning'><i class='fas fa-edit'></i></button></td>" +
                "</tr >";
        })
    })
}

function deleteAlbum(id) {
    var param = { id: id };
    ajaxPOST("/Album/Delete", param).done(function (data) {
        if (data > 0) {
            notify("Album deleted successfully", "success");
            loadData();
        }
        else {
            notify("Failed to delete album", "warning");
        }
    })
}

function getById(id) {
    var param = { id: id };
    var promise = ajaxGet("/Album/GetAlbumById", param);
    promise.done(function (data) {
        console.log(">>>", data);
        if (data != null && !isNullOrEmpty(data)) {
            $("#exampleModal").modal();
            $("#AlbumCover").attr("src", data.Image);
            $("#AlbumName").attr("value", data.Name);
            $("#AlbumId").attr("value", data.Id);
        }
    })
}

function updateAlbum() {
    var form = new FormData();
    var name = document.getElementById("AlbumName").value;
    var id = document.getElementById("AlbumId").value;

    var albumCoverInput = document.getElementById("AlbumCoverInput");
    if (albumCoverInput.files && albumCoverInput.files[0]) {
        form.append("file", albumCoverInput.files[0]);
    }
    form.append("Name", name);
    form.append("Id", id);

    var promise = ajaxPostWithFile("/Album/Update", form);
    promise.done(function (data) {
        if (data > 0) {
            notify("Album updated successfully", "info");
            resetForm();
            loadData();
        }
        else {
            notify("Failed to update album", "warning");
        }
    })
}

function displayImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById("AlbumCover").setAttribute("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function resetForm() {
    $("#exampleModal").modal('hide');
    $("#AlbumCover").attr("src", "");
    $("#AlbumName").attr("value", "");
    $("#AlbumId").attr("value", "");
}