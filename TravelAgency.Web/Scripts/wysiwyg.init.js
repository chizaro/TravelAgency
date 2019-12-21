$(document).ready(() => {
    tinymce.init({
        onSavePluginCallback: function check(ed) {
            var form = $(ed.formElement);
            var isValid = form.valid();
            if (isValid) {
                form.submit();
            }
        },
        setup: function (ed) {
            ed.on('change', function (e) {
                if ($('#tiny_ifr').contents().find('body').text().trim().length !== 0)
                    $('#tiny-error').hide();
            });
        },

        selector: '#tiny',
        language: 'ru',
        menubar: false,
        style_formats: [
            {
                title: "Headers",
                items: [
                    { title: "Header 2", format: "h2" },
                    { title: "Header 3", format: "h3" },
                    { title: "Header 4", format: "h4" },
                    { title: "Header 5", format: "h5" },
                    { title: "Header 6", format: "h6" }
                ]
            },
            {
                title: "Inline",
                items: [
                    { title: "Bold", icon: "bold", format: "bold" },
                    { title: "Italic", icon: "italic", format: "italic" },
                    { title: "Underline", icon: "underline", format: "underline" },
                    { title: "Strikethrough", icon: "strikethrough", format: "strikethrough" },
                    { title: "Superscript", icon: "superscript", format: "superscript" },
                    { title: "Subscript", icon: "subscript", format: "subscript" }
                ]
            },
            {
                title: "Обтекание картинки",
                items: [
                    {
                        title: "Слева", selector: 'img',
                        styles: {
                            'float': 'right',
                            'margin': '0 0 0 2rem'
                        }
                    },
                    {
                        title: "Справа", selector: 'img',
                        styles: {
                            'float': 'left',
                            'margin': '0 2rem 0 0'
                        }
                    }
                ]
            },

        ],

        formats: {
            alignleft: {
                selector: 'img',
                styles: {
                    'float': 'left',
                    'margin': '0 2rem 0 0'
                },
                selector: '*',
                styles: {
                    'text-align': 'left',
                }
            },
            alignright: {
                title: 'Image Right',
                selector: 'img',
                styles: {
                    'float': 'right',
                    'margin': '0 0 0 2rem'
                },
                selector: '*',
                styles: {
                    'text-align': 'right',
                }
            },
        },

        plugins: [
            'advlist autolink lists link image charmap print preview anchor autoresize',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table paste code help wordcount'
        ],
        toolbar: 'undo redo | styleselect forecolor backcolor | align outdent indent | bullist numlist table  | removeformat | image media link | code preview emotions',
    });

});

$('form input[type=submit]').click(function () {
    tinyMCE.triggerSave();
});

$.validator.setDefaults({
    ignore: ''
});
