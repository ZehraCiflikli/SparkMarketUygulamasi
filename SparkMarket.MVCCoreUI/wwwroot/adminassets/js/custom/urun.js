var table;

function DataTableGenerate() {

    var kdvlist;


    $.ajax({
        url: "/AdminPanel/Urun/KdvList",
        method: "post",
        data: {}, // Her satırın id'sine göre veri çekiyoruz
        success: function (response) {


            kdvlist = response.data;
            table = $("#tblUrunler").DataTable({
                "dom": "Bfrtip",
                "responsive": false,
                "lengthChange": true,
                "pageLength": 10,
                "autoWidth": false,
                processing: true,
                serverSide: true,
                "buttons": ["csv", "excel", "pdf", "print", "colvis"],
                language: {
                    url: '/json/datatablestr.json',
                },
                ajax: { url: '/AdminPanel/Urun/List', type: 'post' },
                columns: [
                    { data: 'id', visible: false },
                    { data: 'urunAdi' },
                    { data: 'markaId' },
                    /*    { data: 'aciklama' },*/
                    { data: 'id' },
                    { data: 'kategoriId' },
                    /*    { data: 'birimId' },*/
                    { data: 'kdvId' },
                    { data: 'stok' },
                    { data: 'id' },
                    { data: 'id' },
                    { data: 'id' }
                ],
                columnDefs: [
                    {

                        targets: 2,
                        render: function (data, type, row, meta) {



                            return row["marka"].markaAdi;

                        }
                    },
                    {
                        targets: 3,
                        render: function (data, type, row, meta) {

                            if (row["urunResims"].length > 0) {
                                return "<img width='90px' src='" + row["urunResims"][0].resimUrl + "'>";
                            }
                            else {
                                return "";
                            }

                        }
                    },

                    {
                        targets: 4,
                        render: function (data, type, row, meta) {


                            return row["kategori"].kategoriAdi;


                        }
                    },
                    {
                        targets: 5,
                        render: function (data, type, row, meta) {


                            return row["kdv"].kdvAdi;
                        

                        }
                    },
                    //{
                    //    targets: 5,
                    //    render: function (data, type, row, meta) {



                    //        return row["birim"].birimAdi;

                    //    }
                    //},
                    {
                        targets: 6,
                        render: function (data, type, row, meta) {


                            return data;

                        }
                    },
                    {
                        targets: 7,
                        render: function (data, type, row, meta) {

                            let kdv = "";
                            var kdvid = row["kdvId"];
                            kdv += "<select class='form-control kdvList' urunid='" + data + "'>"
                            for (var i = 0; i < kdvlist.length; i++) {

                                if (kdvid == kdvlist[i].id) {
                                    kdv += "<option selected value='" + kdvlist[i].id + "'>" + kdvlist[i].kdvAdi + "</option>"
                                }
                                else {
                                    kdv += "<option value='" + kdvlist[i].id + "'>" + kdvlist[i].kdvAdi + "</option>"
                                }

                            }
                            kdv += "</select>";
                            return kdv;
                        }
                    },

                    {
                        targets: 8,
                        render: function (data, type, row, meta) {


                            return "<button class='btn btn-primary btnDuzenle' urunid='" + data + "'>DÜZENLE</button>";
                        }
                    },
                    {
                        targets: 9,
                        render: function (data, type, row, meta) {


                            return "<button class='btn btn-danger btnSil' urunid='" + data + "'>SİL</button>";
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



            }).buttons().container().appendTo('#tblUrunler_wrapper .col-md-6:eq(0)');
        }
    });






};

$(function () {

    $('.select2').select2()

    DataTableGenerate();
});


$(function () {

    $('#Aciklama').summernote();
    $('#GAciklama').summernote();

    $("input[data-bootstrap-switch]").each(function () {
        $(this).bootstrapSwitch();
    })


    $(document).on('click', '.btnSil', function () {


        var id = $(this).attr('katid');
        $.ajax({
            url: "/AdminPanel/Kategori/GetKategori",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {

                if (r.result) {
                    $("#GKategoriAdi").val(r.model.kategoriAdi);
                    $("#GAciklama").val(r.model.aciklama);
                    $("#GUstKategoriId").val(r.model.ustKategoriId);
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


    $(document).on('change', '.kdvList', function () {

        var id = $(this).val();
        var urunid = $(this).attr("urunid");

        $.ajax({
            url: "/AdminPanel/Urun/KdvGuncelle",
            type: "post",
            dataType: "json",
            data: { kdvid: id, urunid, urunid },
            success: function (r) {

                if (r.result) {

                }


            },
            error: function () {

            }
        }
        );



    });







})
