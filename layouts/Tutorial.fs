module Tutorial

open Nacara.Core.Types
open Feliz

// Your render function, it is responsible to transform a page into HTML
let render (rendererContext : RendererContext) (pageContext : PageContext) =
    promise {
        let! pageContent =
            rendererContext.MarkdownToHtml(
                pageContext.Content,
                pageContext.RelativePath
            )

        return Page.render
                    rendererContext
                    pageContext
                    (Html.div "tutorial")
    }
