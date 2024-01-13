$(document).ready(function () {
    $('.los-tree-view table tr td:last-child a').hide();
    var tableCount = $('.los-tree-view table').length;
    for (var i = 0; i <= tableCount; i++) {
        var ID1 = $('.los-tree-view table:eq(' + i + ') tr td:last-child input').attr('id');
        $("<label for='" + ID1 + "'>").text($('.los-tree-view table:eq(' + i + ') tr td:last-child a').text()).insertBefore($('.los-tree-view table:eq(' + i + ') tr td:last-child a'));
    }
});