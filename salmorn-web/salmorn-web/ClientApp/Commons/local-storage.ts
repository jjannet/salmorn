

export const Storages  = {
    token: 'salmorn-token',

    getTokenData: function(): string | null {
        let d = localStorage.getItem(this.token);
        if (d) return d as string;
        else return null;
    },
    setTokenData: function(data: string) {
        localStorage.setItem(this.token, data);
    },
    clearToken: function(): void {
        localStorage.removeItem(this.token);
    }


}