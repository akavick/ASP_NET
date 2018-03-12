"use strict";
{
    // Требуется для формирования полного output пути
    let path = require("path");

    // Плагин для очистки выходной папки (bundle) перед созданием новой
    const CleanWebpackPlugin = require("clean-webpack-plugin");

    // Путь к выходной папке
    const bundleFolder = "./wwwroot/bundle/";

    module.exports = {
        // Точка входа в приложение
        entry: "./wwwroot/js/site.js",

        // Выходной файл
        output: {
            path: path.resolve(__dirname, bundleFolder),
            filename: "bundle.js"
        },
        plugins: [
            new CleanWebpackPlugin([bundleFolder])
        ]
    };
}