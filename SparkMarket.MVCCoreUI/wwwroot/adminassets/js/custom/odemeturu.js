var table;


function DataTableGenerate() {

    table = $("#tblOdemeTuru").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        "buttons": ["csv", "excel", "pdf", "print", "colvis"],
        language: {
            url: '/json/datatablestr.json',
        },
        ajax: { url: '/AdminPanel/OdemeTuru/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'odemeTuruAdi' },
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



    }).buttons().container().appendTo('#tblOdemeTuru_wrapper .col-md-6:eq(0)');

};

$(function () {
    DataTableGenerate();
});

$("#btnOdemeTuruEkle").click(function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });
    
    var formData = new FormData();

    

    var OdemeTuruAdi = $("#OdemeTuruAdi").val();
 

    formData.append("OdemeTuruAdi", OdemeTuruAdi)
  
    $.ajax({
        url: "/AdminPanel/OdemeTuru/Add",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {

            $("#frmOdemeTuruEkle")[0].reset();
            
            $("#modalOdemeTuruEkle").modal("hide");

            $("#tblOdemeTuru").DataTable().destroy();


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
            url: "/AdminPanel/OdemeTuru/AktifPasif",
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
            url: "/AdminPanel/OdemeTuru/GetOdemeTuru",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {
                    $("#GOdemeTuruAdi").val(r.model.odemeTuruAdi);
                   
                    $("#modalOdemeTuruGuncelle").modal('show');
                }
                swal.close();



            },
            error: function () {

            }
        }
        );



    });
    $(document).on('click', '#btnOdemeTuruGuncelle', function () {



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

        var OdemeTuruAdi = $("#GOdemeTuruAdi").val();
       

        formData.append("Id",Id)
        formData.append("OdemeTuruAdi", OdemeTuruAdi)
        $.ajax({
            url: "/AdminPanel/OdemeTuru/Update",
            type: "post",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (r) {




                // ---------------Datatable Yok Edildi---------------

                $("#tblOdemeTuru").DataTable().destroy();
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
                    url: "/AdminPanel/OdemeTuru/Delete",
                    type: "post",
                    dataType: "json",
                    data: { id: id },
                    success: function (r) {
                        if (r.result) {
                            $("#tblOdemeTuru").DataTable().destroy();
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
