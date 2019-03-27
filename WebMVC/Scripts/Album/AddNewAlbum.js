function validate() {
    var albumName = document.getElementById("AlbumName");
    if (isNullOrEmpty(albumName.value)) {
        albumName.focus();
        notify('Please enter Album Name', 'warning');
    }
    else {
        document.getElementById("AddAlbumForm").submit();
    }
}