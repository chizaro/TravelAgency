let count = 0;
let inputFile = document.getElementById('Image');
let divTag = document.getElementById('image_item_preview');
let img = document.createElement('img');
img.setAttribute("class", "img-thumbnail img-fluid h-auto w-100");

if (document.getElementById('ImagePath') !== null) {
    img.src = document.getElementById('ImagePath').value;
    divTag.appendChild(img);
}

inputFile.addEventListener("change", function () {
    count++;
    preview(this.files[0]);
});

function preview(file) {
    if (file.type.match(/image.*/)) {
        let reader = new FileReader();
        reader.addEventListener("load", function (event) {
            img.src = event.target.result;
            if (count <= 1)
                divTag.appendChild(img);
        });
        reader.readAsDataURL(file);
    }
}    
