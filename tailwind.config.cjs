/** @type {import('tailwindcss/tailwind-config').TailwindConfig} */
module.exports = {
    mode: 'jit',
    purge: [
        './docs_deploy/**/*.html'
    ],
    darkMode: false, // or 'media' or 'class'
    theme: {
        fontFamily: {
            serif: [ "Josefin Slab", "serif" ]
        },
        container: {
            center: true
        },
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [],
}
