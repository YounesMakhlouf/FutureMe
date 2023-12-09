// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const grid = document.querySelector(".grid");

document.addEventListener("mousemove", (e) => {
    grid.style.setProperty("--x", e.x + "px");
    grid.style.setProperty("--y", e.y + "px");
});
