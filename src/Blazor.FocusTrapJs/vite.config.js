import {resolve} from "path";
import {defineConfig} from "vite";

export default defineConfig({
    build: {
        outDir: "./wwwroot",
        lib: {
            entry: resolve(__dirname, "./FocusTrapScripts.razor.js"),
            name: "BlazorFocusTrap",
            fileName: "FocusTrapScripts",
            formats: ["iife"]
        },
        minify: true,
        terserOptions: {
            compress: {
                drop_console: true,
                drop_debugger: true
            }
        }
    }
});
