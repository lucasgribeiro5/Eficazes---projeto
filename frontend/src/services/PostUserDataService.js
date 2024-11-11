import http from "@/http-common";

class PostUserDataService {

    getUser() {
        return http.get("/Users");
    }

    create(data) {
        return http.post("/Users", data)
    }

    update(data) {
        return http.put("/Users", data)
    }

    login(data) {
        return http.post("/Auth/signIn", data)
    }

    getEnderecos() {
        return http.get("/Endereco/");
    }

    createAddress(data) {
        return http.post("/Endereco/", data)
    }

}

export default new PostUserDataService();