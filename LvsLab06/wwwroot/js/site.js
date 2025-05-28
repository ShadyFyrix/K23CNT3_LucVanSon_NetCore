// Smooth page transitions
document.addEventListener('DOMContentLoaded', function () {
    // Add click event to all links except those with no-transition class
    document.querySelectorAll('a:not(.no-transition)').forEach(link => {
        if (link.href && !link.hash && link.hostname === window.location.hostname) {
            link.addEventListener('click', function (e) {
                // Don't intercept if special key pressed or target is _blank
                if (e.ctrlKey || e.shiftKey || e.metaKey || e.altKey || link.target === '_blank') {
                    return;
                }

                e.preventDefault();

                // Show loading animation
                const loader = document.createElement('div');
                loader.className = 'full-page-loader';
                loader.innerHTML = `
                    <div class="loader-content">
                        <div class="loading-spinner"></div>
                        <p>Loading...</p>
                    </div>
                `;
                document.body.appendChild(loader);

                // Navigate after short delay to allow animation to show
                setTimeout(() => {
                    window.location.href = link.href;
                }, 300);
            });
        }
    });

    // Add tooltips
    $('[data-toggle="tooltip"]').tooltip();
});

// Form validation
(function () {
    'use strict';

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation');

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                form.classList.add('was-validated');
            }, false);
        });
})();