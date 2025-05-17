import { createRoot } from 'react-dom/client'
import App from './App.tsx'
import { Auth0Provider } from '@auth0/auth0-react'
import { Provider } from 'react-redux';
import { store } from './app/store.ts';
import { Provider as ChakraProvider} from './components/ui/provider.tsx';

const env = import.meta.env

createRoot(document.getElementById('root')!).render(
  <Auth0Provider
    domain={env.VITE_AUTH0_DOMAIN}
    clientId={env.VITE_AUTH0_CLIENT_ID}
    authorizationParams={{
      redirect_uri: window.location.origin
    }}>
      <Provider store={store}>
        <ChakraProvider>
            <App />
        </ChakraProvider>
      </Provider>
  </Auth0Provider>
)
