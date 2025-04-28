var table;


function DataTableGenerate() {

    table = $("#tblFiyatTipi").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        "buttons": ["csv", "excel", "pdf", "print", "colvis"],
        language: {
            url: '/json/datatablestr.json',
        },
        ajax: { url: '/AdminPanel/FiyatTipi/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'fiyatTipiAdi' },
            { data: 'aktif' },
            { data: 'id' },
            { data: 'id' },


        ],
        columnDefs: [

            {
                targets: 2,
                render: function (data, type, row, meta) {

                    var katid = row["id"];

                    if (data)

                        return '<input katid=' + katid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox" checked data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';


                    else

                        return '<input katid=' + katid + '  type= "checkbox" data-on-text="AKTİF" data-off-text="PASİF" name = "my-checkbox"  data-bootstrap-switch data-off-color="danger" class="chkAktif" data-on-color="success" > ';

                }
            },

            {
                targets: 3,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-info btnDuzenle' katid=" + data + ">   <i class='fas fa-pencil-alt'></i> DÜZENLE</a > ";

                }
            },

            {
                targets: 4,
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



    }).buttons().container().appendTo('#tblFiyatTipi_wrapper .col-md-6:eq(0)');

};

$(function () {
    DataTableGenerate();
});

$("#btnFiyatTipiEkle").click(function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });
    
    var formData = new FormData();

    

    var FiyatTipiAdi = $("#FiyatTipiAdi").val();
 

    formData.append("FiyatTipiAdi", FiyatTipiAdi)
  
    $.ajax({
        url: "/AdminPanel/FiyatTipi/Add",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {

            $("#frmFiyatTipiEkle")[0].reset();
            
            $("#modalFiyatTipiEkle").modal("hide");

            $("#tblFiyatTipi").DataTable().destroy();


            DataTableGenerate();


            var katlist = "";

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
            url: "/AdminPanel/FiyatTipi/AktifPasif",
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
            url: "/AdminPanel/FiyatTipi/GetFiyatTipi",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {
                    $("#GFiyatTipiAdi").val(r.model.fiyatTipiAdi);
                   
                    $("#modalFiyatTipiGuncelle").modal('show');
                }
                swal.close();



            },
            error: function () {

            }
        }
        );



    });
    $(document).on('click', '#btnFiyatTipiGuncelle', function () {



        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {

                Swal.showLoading();

            },
        });

        var formData = new FormData();

        var Id = $("#GId").val();

        var FiyatTipiAdi = $("#GFiyatTipiAdi").val();
       

        formData.append("Id",Id)
        formData.append("FiyatTipiAdi", FiyatTipiAdi)
        $.ajax({
            url: "/AdminPanel/FiyatTipi/Update",
            type: "post",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (r) {




                // ---------------Datatable Yok Edildi---------------

                $("#tblFiyatTipi").DataTable().destroy();
                //-------------------------------------------------

                // ---------------Datatable Yeniden Oluşturuluyor.---------------
                DataTableGenerate();



                

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
                    url: "/AdminPanel/FiyatTipi/Delete",
                    type: "post",
                    dataType: "json",
                    data: { id: id },
                    success: function (r) {
                        if (r.result) {
                            $("#tblFiyatTipi").DataTable().destroy();
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


})
