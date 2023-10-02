<script>
    $(document).ready(function () {
        $(".item-link").on("click", function (e) {
            e.preventDefault(); // Förhindra standardklickbeteende

            var pageUrl = $(this).attr("href");

            $.ajax({
                url: pageUrl,
                type: "GET",
                success: function (data) {
                    // Uppdatera innehållet på sidan med det laddade data
                    $("#content-container").html(data);
                }
            });
        });
    });
</script>

                        