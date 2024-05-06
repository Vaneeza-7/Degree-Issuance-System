<%@ Page Language="C#" AutoEventWireup="true" CodeFile="confetti.aspx.cs" Inherits="confetti" %>

<!DOCTYPE html>
<html>
<head>
    <title>ASP.NET Confetti</title>
    <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js"></script>
    <script>
        function launchConfetti() {
            var end = Date.now() + 5000; // 5 seconds

            (function frame() {
                confetti({
                    particleCount: 3,
                    angle: 90,
                    spread: 360,
                    origin: { y: 0 }
                });

                if (Date.now() < end) {
                    requestAnimationFrame(frame);
                }
            }());
        }

        window.onload = launchConfetti;
    </script>
</head>
<body>
    <h1>Welcome to Your ASP.NET Page!</h1>
    <p>Confetti should start falling from the top of the page for 5 seconds.</p>
</body>
</html>


