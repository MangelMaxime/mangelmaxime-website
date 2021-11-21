module Page

open Nacara.Core.Types
open Feliz


            // <head>
            //     <meta charSet="UTF-8" />
            //     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            //     <link href="/style.css" rel="stylesheet" />
            //     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
            //     <title>{pageContext.title}</title>
            // </head>

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
            prop.className "flex flex-col bg-gray-100 font-serif"

            prop.children [
                Html.text "maxim22e"

                if true then
                    Html.script [
                        prop.async true
                        prop.src (toUrl "resources/nacara/scripts/live-reload.js")
                    ]
            ]
        ]
    ]
