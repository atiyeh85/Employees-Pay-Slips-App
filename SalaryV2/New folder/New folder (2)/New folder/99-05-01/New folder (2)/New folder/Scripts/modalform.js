// modalform.js

//jquery table script
//open bellow script when want to work with jTable.

//$(function () {
//    $('.table').DataTable({
//        "lengthMenu": [[5, 25, 50, -1], [5, 25, 25, "All"]],
//        "paging": true,
//        "ordering": true,
//        "info": true, "bFilter": false,
//        "columnDefs": [
//                        { "width": "8px", "targets": [0] },
//                        { "width": "8px", "targets": [1] }
//        ],
//        "pagingType": "simple",
//        "responsive": true,
//        "bAutoWidth": false,
//        "bLengthChange": false,
//        "iDisplayLength": 5,
//        "bJQueryUI": false
//        //  "bStateSave" : false,
//        //"sScrollX":"100%",
//        //"sScrollY":"200px",
//        //"bScrollCollapse":false
//    });
//});
//popup script
$(function () {
    $.ajaxSetup({ cache: false });
    $("a.data-modal").on("click", function (e) {
       
        // hide dropdown if any (this is used wehen invoking modal from link in bootstrap dropdown )
        //$(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');
        $('#myModalContent').load(this.href, function () {
           
            $('#myModal').modal({
                

                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $('#progress').show();
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success == true) {
                    $('#myModal').modal('hide');
                    bindMessage(result);//message
                    $('#progress').hide();
                    
                        location.reload();  //Refresh page
              
                    //$("#div-listindex").load(location.href + " #div-listindex");
                    //location.reload();
                }
                else if (result.success == false) {
                    $('#myModal').modal('hide');
                    bindMessage(result);//message
                    $('#progress').hide();
                    if (result.url != "") {
                        $('#replacetarget').load(result.url); //  Load data from the server and place the returned HTML into the matched element
                      
                    }
                }
                else {
                    $('#progress').hide();
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        return false;
    });
}

function bindMessage(result) {
    $('#alert').show();
    $('#alert').empty()//clear div content.
    $('#alert').addClass("alert alert-" + result.alertType)//add class in div .
    $('#alert').html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button> <span>' + result.msg + '</span>')

}