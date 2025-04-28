var table;


function DataTableGenerate() {

    table = $("#tblKategoriler").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        "buttons": ["csv", "excel", "pdf", "print", "colvis"],
        language: {
            url: '/json/datatablestr.json',
        },
        ajax: { url: '/AdminPanel/Kategori/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'kategoriAdi' },
            { data: 'aciklama' },
            { data: 'resim' },
            { data: 'ustKategoriId' },
            { data: 'ustKategoriGorunum' },
            { data: 'aktif' },
            { data: 'id' },
            { data: 'id' },


        ],
        columnDefs: [

            {
                targets: 3,
                render: function (data, type, row, meta) {



                    if (data == null) {
                        return "<img  src='/adminassets/img/catimage.png' width='60px' />";

                    }
                    return "<img categoryName='" + row["kategoriAdi"] + "' class='categoryimage'  src='" + data + "' width='60px' />";

                }
            },
            {
                targets: 6,
                render: function (data, type, row, meta) {

                    var katid = row["id"];

                    if (data)

                        return '<input katid=' + katid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox" checked data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';


                    else

                        return '<input katid=' + katid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox"  data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';

                }
            },

            {
                targets: 7,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-info btnDuzenle' katid=" + data + ">   <i class='fas fa-pencil-alt'></i> DÜZENLE</a > ";

                }
            },

            {
                targets: 8,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-danger btnSil' katid=" + data + "><i class='fas fa-trash'></i> SİL</a > ";
                }
            },




        ],

        initComplete: function (settings, json) {

            // Datatable initilize olduğunda
            $("input[data-bootstrap-switch]").each(function () {
                $(this).bootstrapSwitch();
            })

            $('.select2').select2();
        },

        drawCallback: function () {

            // Arama Yapıldığında, Sayfalama Yapıldığında, Sıralama Yapıldığında Draw yapılıyor
            $("input[data-bootstrap-switch]").each(function () {
                $(this).bootstrapSwitch();
            })

            $('.select2').select2();

        }



    }).buttons().container().appendTo('#tblKategoriler_wrapper .col-md-6:eq(0)');

};

$(function () {
    DataTableGenerate();
});

$("#btnKategoriEkle").click(function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });
    // var form = $("#frmKategoriEkle");
    var formData = new FormData();

    if ($("#FUResim")[0].files[0] != null) {

        var file = $("#FUResim")[0].files[0];
        formData.append(file.name, file);

    }

    var KategoriAdi = $("#KategoriAdi").val();
    var Aciklama = $("#Aciklama").val();
    var UstKategoriId = $("#UstKategoriId").val();


    formData.append("KategoriAdi", KategoriAdi)
    formData.append("Aciklama", Aciklama)
    formData.append("UstKategoriId", UstKategoriId)

    $.ajax({
        url: "/AdminPanel/Kategori/Add",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {

            $("#frmKategoriEkle")[0].reset();
            $('#Aciklama').summernote('code', '');
            $("#modalUrunEkle").modal("hide");

            $("#tblKategoriler").DataTable().destroy();


            DataTableGenerate();


            var katlist = "";

            for (var i = 0; i < r.model.ustKategoriListe.length; i++) {

                katlist += '<option value="' + r.model.ustKategoriListe[i].value + '" data-select2-id="' + r.model.ustKategoriListe[i].value + '">' + r.model.ustKategoriListe[i].text + '</option>';
            }


            $("#UstKategoriId").html(katlist);


            $("#UstKategoriId").trigger("change"); // change eventı buradan tetiklendi


           // $("#frmKategoriEkle").trigger("reset");
           // $("#txtAciklama").val("");


            swal.close();
            if (r.result) {
                Swal.fire({
                    title: "İŞLEM BAŞARILI",
                    text: r.mesaj,
                    icon: "success"
                });
            }





        },
        error: function () {

        }
    }
    );



});





$(function () {
    // Summernote
    $('#Aciklama').summernote();
    $('#GAciklama').summernote();
    $('.select2').select2()
    $("input[data-bootstrap-switch]").each(function () {
        $(this).bootstrapSwitch();
    })
    $(document).on('switchChange.bootstrapSwitch', '.chkAktif', function (event, state) {

        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var id = $(this).attr('katid');
        var aktifpasif = state;
        $.ajax({
            url: "/AdminPanel/Kategori/AktifPasif",
            type: "post",
            dataType: "json",
            data: { id: id, aktif: aktifpasif },
            success: function (r) {


                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                }
            },
            error: function () {

            }
        }
        );



    });

    $('#GAciklama').summernote({
        height: 150,
        // toolbar vb.
    });

    $(document).on('click', '.btnDuzenle', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var id = $(this).attr('katid');
        $("#GId").val(id);

        $.ajax({
            url: "/AdminPanel/Kategori/GetKategori",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {
                    $("#GKategoriAdi").val(r.model.kategoriAdi);
                    // $("#GAciklama").val(r.model.aciklama);
                    $('#GAciklama').summernote('code', r.model.aciklama);


                    if (r.model.ustKategoriId != null) {


                        $("#GUstKategoriId").val(r.model.ustKategoriId);
                    }

                    $("#GUstKategoriId").trigger("change");

                    $("#GResim").attr("src", r.model.resim)
                    $("#modalUrunGuncelle").modal('show');
                }
                swal.close();



            },
            error: function () {

            }
        }
        );



    });
    $(document).on('click', '#btnKategoriGuncelle', function () {



        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var formData = new FormData();

        if ($("#GFUResim")[0].files[0] != null) {

            var file = $("#GFUResim")[0].files[0];
            formData.append(file.name, file);

        }

        var KategoriAdi = $("#GKategoriAdi").val();
        var Aciklama = $("#GAciklama").val();

        var UstKategoriId = $("#GUstKategoriId").val();
        var Id = $("#GId").val();

        formData.append("KategoriAdi", KategoriAdi)
        formData.append("Aciklama", Aciklama)
        formData.append("UstKategoriId", UstKategoriId)
        formData.append("Id", Id)
        $.ajax({
            url: "/AdminPanel/Kategori/Update",
            type: "post",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (r) {




                // ---------------Datatable Yok Edildi---------------

                $("#tblKategoriler").DataTable().destroy();
                //-------------------------------------------------

                // ---------------Datatable Yeniden Oluşturuluyor.---------------
                DataTableGenerate();


                $("#GResim").attr("src", r.model.kategori.resim);
                var katlist = "";

                for (var i = 0; i < r.model.ustKategoriListe.length; i++) {

                    katlist += '<option value="' + r.model.ustKategoriListe[i].value + '" data-select2-id="' + r.model.ustKategoriListe[i].value + '">' + r.model.ustKategoriListe[i].text + '</option>';
                }


                $("#GUstKategoriId").html(katlist);



                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                }




            },
            error: function () {

            }
        }
        );



    });

    $(document).on('click', '.btnSil', function () {


        var id = $(this).attr('katid');

        Swal.fire({

            title: "SİLME İŞLEMİ",
            text: "Silmek İstediğinize Emin Misiniz?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Evet",
            cancelButtonText: "Hayır",
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            reverseButtons: false

        }).then((result) => {
            if (result.isConfirmed) {
                var swal = Swal.fire({
                    title: "LÜTFEN BEKLEYİNİZ...",
                    html: "İşleminiz Yapılıyor",
                    timerProgressBar: true,
                    didOpen: () => {
                        Swal.showLoading();
                    },
                });
                $.ajax({
                    url: "/AdminPanel/Kategori/Delete",
                    type: "post",
                    dataType: "json",
                    data: { id: id },
                    success: function (r) {
                        if (r.result) {
                            $("#tblKategoriler").DataTable().destroy();
                            DataTableGenerate();
                            swal.close();
                            Swal.fire({
                                title: "İŞLEM BAŞARILI",
                                text: r.mesaj,
                                icon: "success"
                            });
                        }
                    },
                    error: function () {
                    }
                });
            }

        });
            


    });


    $(document).on('click', '.categoryimage', function () {


        var src = $(this).attr('src');
        var categoryName = $(this).attr('categoryName');
        $("#imgcategory").attr("src", src);


        $("#categoryname").html(categoryName);
        $("#modalCategoryImage").modal("show");
    });



})
