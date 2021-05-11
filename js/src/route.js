import swaggerJsdoc from "swagger-jsdoc";

const routes = require("express").Router();
const swaggerUi = require("swagger-ui-express");

const options = {
  definition: {
    openapi: "3.0.0",
    info: {
      title: "User API",
      version: "1.0.0",
    },
  },
  apis: ["./route.js"],
};

const swaggerSpec = swaggerJsdoc(options);

router.use("/api-docs", swaggerUi.serve);
router.get("/api-docs", swaggerUi.setup(swaggerSpec));

const UserController = require("../controller/UserController");

// User routes
routes.post("/", UserController.save);
routes.put("/:id", UserController.update);
routes.get("/", UserController.getAll);
routes.get("/:id", UserController.getById);
routes.delete("/:id", UserController.deleteById);

module.exports = routes;
