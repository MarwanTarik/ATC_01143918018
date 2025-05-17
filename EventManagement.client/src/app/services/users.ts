import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { AppUser } from "../../types/common";

const API_URL = import.meta.env.VITE_API_BASE_URL;

export const usersApi = createApi({
    reducerPath: "usersApi",
    baseQuery: fetchBaseQuery({ baseUrl: `${API_URL}/api` }),
    endpoints: (builder) => ({
        getUserById: builder.query<AppUser, string>({
            query: (id) => `users/${id}`,
        }),

        createUser: builder.mutation<AppUser, AppUser>({
            query: (user) => ({ 
                url: `users`, 
                method: 'POST', 
                body: user 
            }),
        }),
    }),
});
