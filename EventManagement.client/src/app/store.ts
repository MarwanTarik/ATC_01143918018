import { configureStore } from '@reduxjs/toolkit';
import { bookingApi } from './services/booking';
import { eventsApi } from './services/events';
import { eventTagsApi } from './services/eventTags';
import { tagsApi } from './services/tags';
import { usersApi } from './services/users';
import { setupListeners } from '@reduxjs/toolkit/query';
import { useDispatch, useSelector } from 'react-redux';
import type { TypedUseSelectorHook } from 'react-redux';

export const store = configureStore({
  reducer: {
    [bookingApi.reducerPath]: bookingApi.reducer,
    [eventsApi.reducerPath]: eventsApi.reducer,
    [eventTagsApi.reducerPath]: eventTagsApi.reducer,
    [tagsApi.reducerPath]: tagsApi.reducer,
    [usersApi.reducerPath]: usersApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
        .concat(
            bookingApi.middleware, 
            eventsApi.middleware, 
            eventTagsApi.middleware, 
            tagsApi.middleware, 
            usersApi.middleware
        ),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
setupListeners(store.dispatch);