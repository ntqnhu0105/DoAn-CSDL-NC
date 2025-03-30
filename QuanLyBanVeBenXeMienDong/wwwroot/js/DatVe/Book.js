function updateGheSelection() {
    var soLuongVe = parseInt(document.getElementById("soLuongVe").value);
    var checkboxes = document.getElementsByClassName("gheCheckbox");
    var checkedCount = 0;

    // Đếm số ghế đã chọn
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            checkedCount++;
        }
    }

    // Giới hạn số ghế được chọn theo số lượng vé
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].disabled = checkedCount >= soLuongVe && !checkboxes[i].checked;
    }
}

// Gọi hàm khi trang tải để khởi tạo
document.addEventListener("DOMContentLoaded", updateGheSelection);