module Page

open Nacara.Core.Types
open Feliz

let private navbar =
    Html.div [
        prop.className "py-8 z-10"

        prop.children [
            Html.div [
                prop.className "container px-6"

                prop.children [
                    Html.div [
                        prop.className "flex items-center justify-between"

                        prop.children [
                            Html.div [
                                prop.className "text-2xl"
                                prop.text "Fable Adventure"
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

let render
    (rendererContext : RendererContext)
    (pageContext : PageContext)
    (content : ReactElement) =

    let titleStr =
        match pageContext.Title with
        | Some title ->
            rendererContext.Config.SiteMetadata.Title  + " · " + title
        | None ->
            rendererContext.Config.SiteMetadata.Title

    let toUrl (url : string) =
        rendererContext.Config.SiteMetadata.BaseUrl + url

    Html.html [
        Html.head [
            Html.meta [
                prop.charset "UTF-8"
            ]

            Html.meta [
                prop.name "viewport"
                prop.content "width=device-width, initial-scale=1.0"
            ]

            Html.link [
                prop.href "/style.css"
                prop.rel "stylesheet"
            ]

            Html.link [
                prop.rel "stylesheet"
                prop.href "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"
                prop.integrity "sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ=="
                prop.crossOrigin.anonymous
                prop.custom ("referrerPolicy", "no-referrer")
            ]

            Html.title titleStr
        ]

        Html.body [
            prop.className "flex flex-col bg-gray-100 font-serif min-h-screen"

            prop.children [
                navbar

                Html.div [
                    prop.className "page-content"
                    prop.children [
                        content
                    ]
                ]

                Html.div [
                    prop.className "flex-shrink-0 h-32 mt-4 bg-gray-800"

                    prop.children [
                        Html.div [
                            prop.className "container text-center text-white"

                            prop.text "© 2021 Copyright by Mangel Maxime . All rights reserved."
                        ]
                    ]
                ]

                if true then
                    Html.script [
                        prop.async true
                        prop.src (toUrl "resources/nacara/scripts/live-reload.js")
                    ]
            ]
        ]
    ]
